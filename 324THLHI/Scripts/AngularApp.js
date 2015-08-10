angular.module('LIKApp', [])
  .controller('GenerateLIKPDF', ['$scope', '$location', '$window', GenerateLIKPDF]);

function GenerateLIKPDF($scope, $location, $window) {
    $scope.LodgingDate = [];
    $scope.LodgingDate[0] = { value: '' };
    $scope.Unit = '';
    $scope.Name = '';
    $scope.Rank = '';
    $scope.Address = '';
    $scope.CSZ = '';
    $scope.PhoneAreaCode = '';
    $scope.Phone = '';
    $scope.WorkPhoneAreaCode = '';
    $scope.WorkPhone = '';
    $scope.Initials = '';
    $scope.Mileage = '';
    $scope.Email = '';

    $scope.AddLodgingDate = function () {
        $scope.LodgingDate[$scope.LodgingDate.length] = {value: ''};
    }

    $scope.GeneratePDF = function () {
        
        var UploadObject = CreateUploadObject();
        var url = $location.protocol() + '://' + $location.host() + ':' + $location.port()

        //url = url + '/api/PDFCreator/getPDF';
        url = url + '/CreatePDF';
        url = url + '?Address=' + UploadObject.Address +
            '&CSZ=' + UploadObject.CSZ +
            '&Email=' + UploadObject.Email +
            '&Initials=' + UploadObject.Initials;
            for (var i = 0; i < UploadObject.LodgingDates.length; i++)
            {
                url = url + '&LodgingDates[' + i + ']=' + UploadObject.LodgingDates[i];
            }
            url = url + 
            '&Mileage=' + UploadObject.Mileage +
            '&Name=' + UploadObject.Name + 
            '&Phone=' + UploadObject.Phone +
            '&PhoneAreaCode=' + UploadObject.PhoneAreaCode +
            '&Rank=' + UploadObject.Rank +
            '&Unit=' + UploadObject.Unit +
            '&WorkPhone=' + UploadObject.WorkPhone +
            '&WorkPhoneAreaCode=' + UploadObject.WorkPhoneAreaCode;
        $window.open(url);
    }

    function CreateUploadObject() {
        var uploadObject = {};
        uploadObject.LodgingDates = [];
        for (var i = 0; i < $scope.LodgingDate.length; i++) {
            uploadObject.LodgingDates.push($scope.LodgingDate[i].value);
        }
        uploadObject.Unit = $scope.Unit;
        uploadObject.Name = $scope.Name;
        uploadObject.Rank = $scope.Rank;
        uploadObject.Address = $scope.Address;
        uploadObject.CSZ = $scope.CSZ;
        uploadObject.PhoneAreaCode = $scope.PhoneAreaCode;
        uploadObject.Phone = $scope.Phone;
        uploadObject.WorkPhoneAreaCode = $scope.WorkPhoneAreaCode;
        uploadObject.WorkPhone = $scope.WorkPhone;
        uploadObject.Initials = $scope.Initials;
        uploadObject.Mileage = $scope.Mileage;
        uploadObject.Email = $scope.Email;
        return uploadObject;
    }
}