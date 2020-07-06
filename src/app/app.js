const app = angular.module("CaraForBP", ["ngRoute"]);

app.config(($routeProvider) => {
  $routeProvider
    .when("/", {
      templateUrl: "app/views/home.html",
      controller: "HomeCtrl",
    })
    .when("/user", {
      templateUrl: "app/views/user.html",
      controller: "UserCtrl",
    })
    .when("/integrator", {
      templateUrl: "app/views/integrator.html",
      controller: "IntegratorCtrl",
    })
    .otherwise({ redirectTo: "/" });
});

app.value("apiUrl", "http://localhost:58905/api/");
