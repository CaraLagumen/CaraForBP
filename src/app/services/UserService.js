app.factory("UserService", [
  "$http",
  "apiUrl",
  function ($http, apiUrl) {
    let output = {};

    output.PaymentProcess = function (payment) {
      $http.post(apiUrl + "PaymentDetail", payment).then(
        function success(res) {
          console.log(res);
        },
        function error(res) {
          console.log(res);
        }
      );
    };

    return output;
  },
]);
