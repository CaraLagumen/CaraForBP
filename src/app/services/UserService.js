app.factory("UserService", [
  "$http",
  "apiUrl",
  function ($http, apiUrl) {
    let output = {};

    output.paymentProcess = function (payment) {
      return $http.post(apiUrl + "PaymentDetail", payment);
    };

    return output;
  },
]);
