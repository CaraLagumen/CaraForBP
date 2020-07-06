app.controller("UserCtrl", [
  "$scope",
  "UserService",
  function ($scope, UserService) {
    $scope.isValidDate = false;

    $scope.DateValidator = function () {
      if ($scope.expirationDateMonth && $scope.expirationDateYear) {
        const now = new Date(Date.now()).setDate(1);
        const month = parseInt($scope.expirationDateMonth) - 1;
        const year = 2000 + parseInt($scope.expirationDateYear);
        const inputDate = new Date().setFullYear(year, month, 1);

        if (inputDate >= now) {
          $scope.isValidDate = true;
        } else {
          $scope.isValidDate = false;

          $scope.paymentDetailForm.expirationDateYear.$setValidity(
            "required",
            false
          );
        }
      }
    };

    $scope.PaymentSubmit = function () {
      let cardOwnerZip = $scope.cardOwnerZip1;
      if ($scope.cardOwnerZip2)
        cardOwnerZip = $scope.cardOwnerZip1 + "-" + $scope.cardOwnerZip2;

      let transactionAmount = $scope.transactionAmount;
      if (!$scope.transactionAmount.includes("."))
        transactionAmount = $scope.transactionAmount + ".00";

      const payment = {
        CardOwnerName: $scope.cardOwnerName,
        CardOwnerStreet: $scope.cardOwnerStreet,
        CardOwnerZip: cardOwnerZip,
        CardNumber: $scope.cardNumber,
        ExpirationDate:
          $scope.expirationDateMonth + "/" + $scope.expirationDateYear,
        CVV: $scope.cvv,
        TransactionAmount: transactionAmount,
      };

      UserService.PaymentProcess(payment);
    };
  },
]);
