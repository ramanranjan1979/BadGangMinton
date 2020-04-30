var urlPath = window.location.pathname;

$(function () {
    ko.applyBindings(loginListVM);
    loginListVM.loadLogins();
});

var loginListVM = {
    Logins: ko.observableArray([]),

    loadLogins: function () {
        var self = this;
        //Ajax Call Get All Articles
        $.ajax({
            type: "GET",
            url: 'http://localhost:53895/System/' + '/GetLoginList',
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (data) {
                self.Logins(data); //Put the response in ObservableArray
            },
            error: function (err) {
                alert(err.status + " : " + err.statusText);
            }
        });

    }
};

function Logins(l) {
    this.Id = ko.observable(l.Id);
    this.UserName = ko.observable(l.UserName);
    this.Password = ko.observable(l.Password);
    this.CreatedOn = ko.observable(l.CreatedOn);
    this.ModifiedOn = ko.observable(l.ModifiedOn);
    this.LockedOn = ko.observable(l.LockedOn);
    this.IsActive = ko.observable(l.IsActive);
    this.IsLock = ko.observable(l.IsLock);


}


//public BGO.Contact.Person Person { get; set; }