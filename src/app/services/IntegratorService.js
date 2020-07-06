app.factory("IntegratorService", [
  "$http",
  "apiUrl",
  function ($http, apiUrl) {
    const transaction = {};

    transaction.TransactionProcess = function (transaction) {
      $http
        .post(apiUrl + "TransactionDetail", transaction)
        .success(function (data) {
          callback(data);
        })
        .error(function (err) {
          errorCallback(err);
        });
    };

    return transaction;
  },
]);
