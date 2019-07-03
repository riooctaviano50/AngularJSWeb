angular.module("CrudDemoApp.controllers", []).
    controller("MainController", function ($scope,PlayerService) {
        $scope.message = "Main Controller";

        PlayerService.GetPlayersfromDB().then(function (d) {
            $scope.listPlayers = d.data.list;
        })
    }).
    controller("AddPlayerController", function ($scope,PlayerService) {
        $scope.message = "Add player details";

        $scope.AddPlayer = function()
        {
            PlayerService.AddPlayer($scope.player);
        }
    }).controller("EditPlayerController", function ($scope,PlayerService,$routeParams) {
        $scope.message = "Update player details";
        var id = $routeParams.id;

        PlayerService.GetPlayersByID(id).then(function (d) {
            $scope.player = d.data.player;
        })

    }).controller("DeletePlayerController", function ($scope) {
        $scope.message = "Delete player details";
    }).
    factory("PlayerService", ["$http", function ($http) {
    var fac = {};
    fac.GetPlayersFromDB = function () {
        return $http.get("/Player/GetPlayers");
    }

    fac.GetPlayersByID = function (id) {
        return $http.get("/Player/GetPlayersById", { params: { id: id } } );
    }

    fac.AddPlayer = function (player) {
        $http.post("/Player/AddPlayer", player).success(function (response) {
            alert(response.status);
        });
    }

    fac.UpdatePlayer = function (player) {
        $http.post("/Player/UpdatePlayer", player).success(function (response) {
            alert(response.status);
        });
    }

    fac.DeletePlayer = function (id) {
        $http.post("/Player/DeletePlayer", { id: id } ).success(function (response) {
            alert(response.status);
        });
    }

    return fac;
}])