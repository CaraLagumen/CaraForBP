//VALIDATORS-----------------------------------------------

app.directive("nameValidator", function () {
  const regex = /^[a-zA-Z \-']+$/;

  return {
    require: "ngModel",
    link: function (scope, el, attr, ctrl) {
      ctrl.$validators.nameValidator = function (modelValue, viewValue) {
        return viewValue ? regex.test(viewValue) : true;
      };
    },
  };
});

app.directive("streetValidator", function () {
  const regex = /^\d{1,10}\s([\s\.a-zA-Z]){1,100}$/;

  return {
    require: "ngModel",
    link: function (scope, el, attr, ctrl) {
      ctrl.$validators.streetValidator = function (modelValue, viewValue) {
        return regex.test(viewValue);
      };
    },
  };
});

app.directive("streetNameValidator", function () {
  const regex = /^[\sa-zA-Z0-9]+$/;

  return {
    require: "ngModel",
    link: function (scope, el, attr, ctrl) {
      ctrl.$validators.streetNameValidator = function (modelValue, viewValue) {
        return viewValue ? regex.test(viewValue) : true;
      };
    },
  };
});

//https://stackoverflow.com/a/28511774/12765256
app.directive("luhnValidator", function () {
  return {
    require: "ngModel",
    link: function (scope, el, attr, ctrl) {
      ctrl.$validators.luhnValidator = function (modelValue, viewValue) {
        return viewValue
          ? !(
              viewValue
                .replace(/\D/g, "")
                .split("")
                .reverse()
                .reduce(function (a, d, i) {
                  return (a + d * (i % 2 ? 2.2 : 1)) | 0;
                }, 0) % 10
            )
          : true;
      };
    },
  };
});

//MISC-----------------------------------------------

//https://stackoverflow.com/a/19675023/12765256
app.directive("onlyDigits", function () {
  return {
    restrict: "A",
    require: "?ngModel",
    link: function (scope, el, attr, ctrl) {
      ctrl.$parsers.push(function (inputValue) {
        if (inputValue == undefined) return "";

        const transformedInput = inputValue.replace(/[^0-9.]/g, "");

        if (transformedInput !== inputValue) {
          ctrl.$setViewValue(transformedInput);
          ctrl.$render();
        }

        return transformedInput;
      });
    },
  };
});
