angular.module('LIKApp', [])
  .controller('GenerateLIKPDF', ['$scope', '$http' ,GenerateLIKPDF]);

function GenerateLIKPDF($scope, $http) {
    $scope.LodgingDate = [];
    $scope.LodgingDate[0] = ""; 
    $scope.Unit = "";
    $scope.Name = "";
    $scope.Rank = "";
    $scope.Address = "";
    $scope.CSZ = "";
    $scope.PhoneAreaCode = "";
    $scope.Phone = "";
    $scope.WorkPhoneAreaCode = "";
    $scope.WorkPhone = "";
    $scope.Initials = "";
    $scope.Mileage = "";
    $scope.Email = "";

    $scope.AddLodgingDate = function () {
        $scope.LodgingDate.push("");
    }

    $scope.GeneratePDF = function () {
        $scope.LodgingDate.push("");
    }
}