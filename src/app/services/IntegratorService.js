app.factory("IntegratorService", [
  "$http",
  "apiUrl",
  function ($http, apiUrl) {
    let output = {};

    output.transactionProcess = function (payment) {
      return $http.post(apiUrl + "PaymentDetail", payment);
    };

    return output;
  },
]);
