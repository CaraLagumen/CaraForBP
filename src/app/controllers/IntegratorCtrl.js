app.controller("IntegratorCtrl", [
  "$scope",
  "IntegratorService",
  function ($scope, IntegratorService) {
    $scope.isValidDate = false;
    $scope.processed = false;
    $scope.processing = false;
    $scope.response = "";
    $scope.requestedTransactionAmount = "";
    $scope.processedTransactionAmount = "";

    //TEST
    $scope.cardOwnerName = "Cara Lagumen";
    $scope.cardOwnerStreet = "1234 Street Address";
    $scope.cardOwnerZip1 = "12345";
    $scope.cardOwnerZip2 = "6789";
    $scope.cardNumber = "4111111111111111";
    $scope.expirationDateMonth = "12";
    $scope.expirationDateYear = "34";
    $scope.cvv = "1234";
    $scope.transactionAmount = "1234.56";

    let processTimer;

    $scope.transactionProcess = function () {
      $scope.processing = true;

      processTimer = setTimeout(function () {
        $scope.transactionSubmit();
      }, 5000);
    };

    $scope.transactionCancel = function () {
      $scope.processed = true;
      $scope.processing = false;
      $scope.response = "Canceled";
      $scope.requestedTransactionAmount = "$" + $scope.transactionAmount;
      $scope.processedTransactionAmount = "$0.00";

      clearTimeout(processTimer);
    };

    $scope.transactionSubmit = function () {
      let cardOwnerZip = $scope.cardOwnerZip1;
      if ($scope.cardOwnerZip2)
        cardOwnerZip = $scope.cardOwnerZip1 + "-" + $scope.cardOwnerZip2;

      let transactionAmount = $scope.transactionAmount;
      if (!$scope.transactionAmount.includes("."))
        transactionAmount = $scope.transactionAmount + ".00";

      const transaction = {
        CardOwnerName: $scope.cardOwnerName,
        CardOwnerStreet: $scope.cardOwnerStreet,
        CardOwnerZip: cardOwnerZip,
        CardNumber: $scope.cardNumber,
        ExpirationDate:
          $scope.expirationDateMonth + "/" + $scope.expirationDateYear,
        CVV: $scope.cvv,
        TransactionAmount: transactionAmount,
        Type: "Integrator",
      };

      IntegratorService.transactionProcess(transaction).then(
        function success(res) {
          $scope.processed = true;
          $scope.processing = false;
          $scope.response = res.data.ProcessorResponse;
          $scope.requestedTransactionAmount = "$" + res.data.RequestedAmount;
          $scope.processedTransactionAmount = "$" + res.data.ProcessedAmount;

          console.log(res);
        },
        function error(res) {
          $scope.processed = true;
          $scope.processing = false;
          $scope.response = "Declined";
          $scope.requestedTransactionAmount = "$" + transactionAmount;
          $scope.processedTransactionAmount = "$0.00";

          console.log(res);
        }
      );
    };

    $scope.clearForm = function () {
      $scope.cardOwnerName = "";
      $scope.cardOwnerStreet = "";
      $scope.cardOwnerZip1 = "";
      $scope.cardOwnerZip2 = "";
      $scope.cardNumber = "";
      $scope.expirationDateMonth = "";
      $scope.expirationDateYear = "";
      $scope.cvv = "";
      $scope.transactionAmount = "";
      $scope.processed = false;
      $scope.processing = false;
    };
  },
]);
