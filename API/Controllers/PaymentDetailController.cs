﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API.Models;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentDetailController : ControllerBase
    {
        private readonly PaymentDetailContext _context;

        public PaymentDetailController(PaymentDetailContext context)
        {
            _context = context;
        }

        // GET: api/PaymentDetail
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PaymentDetail>>> GetPaymentDetails()
        {
            return await _context.PaymentDetails.ToListAsync();
        }

        // GET: api/PaymentDetail/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PaymentDetail>> GetPaymentDetail(int id)
        {
            var paymentDetail = await _context.PaymentDetails.FindAsync(id);

            if (paymentDetail == null)
            {
                return NotFound();
            }

            return paymentDetail;
        }

        // PUT: api/PaymentDetail/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPaymentDetail(int id, PaymentDetail paymentDetail)
        {
            if (id != paymentDetail.PMId)
            {
                return BadRequest();
            }

            _context.Entry(paymentDetail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PaymentDetailExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/PaymentDetail
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<PaymentDetail>> PostPaymentDetail(PaymentDetail paymentDetail)
        {
            paymentDetail.ProcessorResponse = "Approved";
            paymentDetail.RequestedAmount = paymentDetail.TransactionAmount;
            paymentDetail.ProcessedAmount = paymentDetail.TransactionAmount;

            if (paymentDetail.Type == "User")
            {
                if (!ValidateLuhn(paymentDetail.CardNumber))
                {
                    throw new ArgumentException($"Card number is invalid.");
                }
            }

            if (paymentDetail.Type == "Integrator")
            {
                if (ValidateName(paymentDetail.CardOwnerName) ||
                ValidateAmountOver(paymentDetail.TransactionAmount))
                {
                    paymentDetail.ProcessorResponse = "Declined";
                    paymentDetail.ProcessedAmount = "0.00";
                }
                else if (ValidateAmountBetween(paymentDetail.TransactionAmount))
                {
                    paymentDetail.ProcessorResponse = "Partially approved";
                    paymentDetail.ProcessedAmount = "5.00";
                }
            }

            _context.PaymentDetails.Add(paymentDetail);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPaymentDetail", new { id = paymentDetail.PMId }, paymentDetail);
        }

        // DELETE: api/PaymentDetail/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PaymentDetail>> DeletePaymentDetail(int id)
        {
            var paymentDetail = await _context.PaymentDetails.FindAsync(id);
            if (paymentDetail == null)
            {
                return NotFound();
            }

            _context.PaymentDetails.Remove(paymentDetail);
            await _context.SaveChangesAsync();

            return paymentDetail;
        }

        private bool PaymentDetailExists(int id)
        {
            return _context.PaymentDetails.Any(e => e.PMId == id);
        }

        //VALIDATORS

        //Card number Luhn check; algo from: https://stackoverflow.com/a/40491537/12765256
        private static bool ValidateLuhn(string digits)
        {
            return digits.All(char.IsDigit) && digits.Reverse()
                .Select(c => c - 48)
                .Select((thisNum, i) => i % 2 == 0
                    ? thisNum
                    : ((thisNum *= 2) > 9 ? thisNum - 9 : thisNum)
                ).Sum() % 10 == 0;
        }

        //Card owner name must start with A or a
        private static bool ValidateName(string name)
        {
            return name[0] == 'a' || name[0] == 'A';
        }

        //Transaction amount > 10
        private static bool ValidateAmountOver(string amount)
        {
            return decimal.Parse(amount) > 10;
        }

        //Transaction amount > 5 && amount < 10
        private static bool ValidateAmountBetween(string amount)
        {
            return decimal.Parse(amount) > 5 && decimal.Parse(amount) < 10;
        }

    }
}
