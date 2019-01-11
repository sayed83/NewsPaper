var model = { user: "IDB" };
var app = angular.module("BangladeshToday", ['ngSanitize', "ngRoute"]);


app.config(function ($routeProvider) {
    $routeProvider
        .when("/", {
            templateUrl: "main.html"
        })
        .when("/details", {
            templateUrl: "details.html"
        })
        .when("/Category", {
            templateUrl: "Category.html"
        })
    
        
});




app.service('MyService', function ($http, $q) {
    this.Service = function (method, url1, data1) {
        var d = $q.defer();
        $http({
            method: method,
            url: url1,
            data: data1,
        }).then(function successCallback(response) {
            res = response.data;
            d.resolve(res);
        }, function errorCallback(response) {
            d.reject(response);
        });
        res = d.promise;
        return res;
    }
});



app.controller("TestController", function ($scope, $http, MyService) {
    //initial values
    $scope.allNews = [];
    $scope.Categories = [];
    $scope.FeatureNews = [];

    $scope.HotNews = [];
    $scope.HotNewsShort = [];

    $scope.GetBusinessCategory = [];
    $scope.GetNationalCategory = [];
    $scope.GetInternationalCategory = [];

    $scope.GetEntertainmentCategory = [];
    $scope.GetEntertainmentCategoryShort = [];

    $scope.GetLatestNews = [];
    $scope.GetLatestNewsShort = [];
    
    $scope.EditorPicks = [];
    $scope.EditorPicksShort = [];

    $scope.GetPoliticsCategory = [];
    $scope.GetPoliticsCategoryShort = [];

    $scope.GetSportsCategory = [];
    $scope.GetSportsCategoryShort = [];

    $scope.GetScienceTechCategory = [];
    $scope.GetScienceTechCategoryShort = [];

    $scope.GetArtandCultureCategory = [];
    $scope.GetArtandCultureCategoryShort = [];

    $scope.MoreNews = [];
    $scope.CategorywiseNews = [];

    $scope.NewsByCategory = [];
    $scope.NewsByCategoryShort = [];

    //$http.get('/api/Newsinfoesapi/').success(function (data, status, headers, config) {
    //    $scope.allNews = data;
    //    alert(data);
    //}).error(function (data, status, headers, config) {
    //    alert("An error Occured")
    //    });

    b = MyService.Service("GET", '/api/Newsinfoesapi/', '')
    b.then(function (r) {
        $scope.allNews = r;
    });

    b = MyService.Service("GET", '/api/Newsinfoesapi/GetCategories', '')
    b.then(function (r) {
        $scope.Categories = r; 
    });

    b = MyService.Service("GET", '/api/Newsinfoesapi/GetFeatureNews', '')
    b.then(function (r) {
        $scope.FeatureNews = r;
    });

    //b = MyService.Service("GET", '/api/Newsinfoesapi/SubFeatureNews', '')
    //b.then(function (r) {
    //    $scope.SubFeatureNews = r;
    //});


    b = MyService.Service("GET", '/api/Newsinfoesapi/GetHotNews', '')
    b.then(function (r) {
        $scope.HotNews = r;

        angular.forEach(r, function (value, key) {
            words = 60;
            var inputWords = value.description.split(/\s+/);
            if (inputWords.length > words) {
                input = inputWords.slice(0, words).join(' ') + '\u2026' + "</p>";
                value.description = input
            }


            // alert(key + ': ' + value.description);
        });



        $scope.HotNewsShort = r;
    });


    b = MyService.Service("GET", '/api/Newsinfoesapi/GetBusinessCategory', '')
    b.then(function (r) {
        $scope.GetBusinessCategory = r;
    });



    b = MyService.Service("GET", '/api/Newsinfoesapi/GetNationalCategory', '')
    b.then(function (r) {
        $scope.GetNationalCategory = r;
    });



    b = MyService.Service("GET",'/api/Newsinfoesapi/GetInternationalCategory', '')
    b.then(function (r) {
        $scope.GetInternationalCategory = r;
    });



    b = MyService.Service("GET",'/api/Newsinfoesapi/GetEntertainmentCategory', '')
    b.then(function (r) {
        $scope.GetEntertainmentCategory = r;


        angular.forEach(r, function (value, key) {
            words = 60;
            var inputWords = value.description.split(/\s+/);
            if (inputWords.length > words) {
                input = inputWords.slice(0, words).join(' ') + '\u2026' + "</p>";
                value.description = input
            }


           // alert(key + ': ' + value.description);
        });



        $scope.GetEntertainmentCategoryShort = r;

    });

    b = MyService.Service("GET",'/api/Newsinfoesapi/GetLatestNews', '')
    b.then(function (r) {
        $scope.GetLatestNews = r;

        angular.forEach(r, function (value, key) {
            words = 60;
            var inputWords = value.description.split(/\s+/);
            if (inputWords.length > words) {
                input = inputWords.slice(0, words).join(' ') + '\u2026' + "</p>";
                value.description = input
            }
            

         //   alert(key + ': ' + value.description);
        });


        
        $scope.GetLatestNewsShort = r;
       // alert($scope.GetLatestNews);

     
       



    });

   
    b = MyService.Service("GET", '/api/Newsinfoesapi/EditorPicks', '')
    b.then(function (r) {

        $scope.EditorPicks = r;


        angular.forEach(r, function (value, key) {
            words = 60;
            var inputWords = value.description.split(/\s+/);
            if (inputWords.length > words) {
                input = inputWords.slice(0, words).join(' ') + '\u2026' + "</p>";
                value.description = input
            }


            // alert(key + ': ' + value.description);
        });



        $scope.EditorPicksShort = r;
    });


    b = MyService.Service("GET", '/api/Newsinfoesapi/GetPoliticsCategory', '')
    b.then(function (r) {
        $scope.GetPoliticsCategory = r;

        angular.forEach(r, function (value, key) {
            words = 60;
            var inputWords = value.description.split(/\s+/);
            if (inputWords.length > words) {
                input = inputWords.slice(0, words).join(' ') + '\u2026' + "</p>";
                value.description = input
            }


            // alert(key + ': ' + value.description);
        });



        $scope.GetPoliticsCategoryShort = r;
    });


    b = MyService.Service("GET", '/api/Newsinfoesapi/GetSportsCategory', '')
    b.then(function (r) {
        $scope.GetSportsCategory = r;

        angular.forEach(r, function (value, key) {
            words = 60;
            var inputWords = value.description.split(/\s+/);
            if (inputWords.length > words) {
                input = inputWords.slice(0, words).join(' ') + '\u2026' + "</p>";
                value.description = input
            }


            // alert(key + ': ' + value.description);
        });



        $scope.GetSportsCategoryShort = r;
    });

    b = MyService.Service("GET", '/api/Newsinfoesapi/GetScienceTechCategory', '')
    b.then(function (r) {
        $scope.GetScienceTechCategory = r;

        angular.forEach(r, function (value, key) {
            words = 60;
            var inputWords = value.description.split(/\s+/);
            if (inputWords.length > words) {
                input = inputWords.slice(0, words).join(' ') + '\u2026' + "</p>";
                value.description = input
            }


            // alert(key + ': ' + value.description);
        });



        $scope.GetScienceTechCategoryShort = r;
    });

    b = MyService.Service("GET", '/api/Newsinfoesapi/GetArtandCultureCategory', '')
    b.then(function (r) {
        $scope.GetArtandCultureCategory = r;

        angular.forEach(r, function (value, key) {
            words = 60;
            var inputWords = value.description.split(/\s+/);
            if (inputWords.length > words) {
                input = inputWords.slice(0, words).join(' ') + '\u2026' + "</p>";
                value.description = input
            }


            // alert(key + ': ' + value.description);
        });



        $scope.GetArtandCultureCategoryShort = r;
    });

    b = MyService.Service("GET", '/api/Newsinfoesapi/MoreNews', '')
    b.then(function (r) {
        $scope.MoreNews = r;
    });

    b = MyService.Service("GET", '/api/Newsinfoesapi/CategorywiseNews', '')
    b.then(function (r) {
        $scope.CategorywiseNews = r;
    });

    //b = MyService.Service("GET", '/api/Newsinfoesapi/GetKeyword', '')
    //b.then(function (r) {
    //    $scope.GetKeyword = r;
    //});


   
    //$scope.GetKeyword = [];
    $scope.NewsByTitle = '';
    $scope.myValue = false;
    $scope.$parent.subview1 = "firstdiv.html";

    $scope.DetailsFromTitle = function (a) {

        b = MyService.Service("GET", '/api/newsinfoesapi/'+a, '')
        b.then(function (r) {
            $scope.NewsByTitle = r.title;
            $scope.description = r.description;
            $scope.category = r.category;
            $scope.author = r.author;
            $scope.datetime = r.datetime;
            $scope.captionPicture = r.captionPicture;

            //$()
           // featured - posts - grid
            //alert($scope.NewsByTitle);
            $scope.myValue = true;
        });

    }


    $scope.GetNewsByCategory = function (a) {
       // alert(a);
        b = MyService.Service("GET", '/api/newsinfoesapi/GetNewByCategory?cat=' + a, '')
        b.then(function (r) {
            $scope.NewsByCategory = r;
            //alert($scope.NewsByCategory);
            $scope.myValue = true;

            angular.forEach(r, function (value, key) {
                words = 60;
                var inputWords = value.description.split(/\s+/);
                if (inputWords.length > words) {
                    input = inputWords.slice(0, words).join(' ') + '\u2026' + "</p>";
                    value.description = input
                }


                // alert(key + ': ' + value.description);
            });



            $scope.NewsByCategoryShort = r;

        });

    }

    $scope.showDangerousDiv = function () {
        $scope.myValue = false;
    }

});
