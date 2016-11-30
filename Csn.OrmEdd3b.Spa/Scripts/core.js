//all angular code for our app 
// public/core.js
var fmiFe = angular.module('CsnOrmEdd', []);

function mainController($scope, $http) {
    $scope.formData = {};

    // when landing on the page, get all todos and show them
    $http.get('http://localhost:1977/api/persons/')
		.success(function (data) {
		    $scope.persons = data;
		    console.log(data);
		})
		.error(function (data) {
		    console.log('Error: ' + data);
		});

    // when submitting the add form, send the text to the node API
    $scope.createPerson = function () {
        $http.post('http://localhost:1977/api/persons/', $scope.formData)
			.success(function (data) {
			    $scope.persons.push($scope.formData);
			    $scope.formData = {}; // clear the form so our user is ready to enter another
			    // $scope.persons = data
			    console.log(data);
			})
			.error(function (data) {
			    console.log('Error: ' + data);
			});
    };

    // Response to preflight request doesn't pass access control check: No 'Access-Control-Allow-Origin' header is present on the requested resource. Origin 'http://localhost:61451' is therefore not allowed access. The response had HTTP status code 400.
    // delete a todo after checking it
    $scope.deletePerson = function (id) {
        $http.delete('http://localhost:1977/api/persons/' + id)
			.success(function (data) {
			    $scope.persons = data;
			    console.log(data);
			})
			.error(function (data) {
			    console.log('Error: ' + data);
			});
    };
}

/*
[
  {
    "Id": 2,
    "Name": "Stoyan",
    "FamilyName": "Cheresharov",
    "BirthDate": "1976-09-09T00:00:00",
    "Address": "7 Avliga str",
    "Phones": null
  },
  {
    "Id": 4,
    "Name": "sample string 2",
    "FamilyName": "sample string 3",
    "BirthDate": "2016-11-29T15:23:37.877",
    "Address": "sample string 5",
    "Phones": null
  }
]
*/