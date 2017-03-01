function AppViewModel() {
    var self = this;

    self.startDate = ko.observable("2016-01-01");
    self.endDate = ko.observable("2016-12-31");
    self.agents = ko.observableArray([]);
    self.filter = ko.observable();

    self.filteredAgents = ko.computed(function() {
        var filter = self.filter();

        if (!filter) {
            return self.agents();
        } else {
            return ko.utils.arrayFilter(self.agents(), function (item) {
                return ko.utils.stringStartsWith(item.FullName, filter);
            });
        }
    });

    self.getAgents = function () {
        var data = { start: this.startDate(), end: this.endDate() }
        self.agents.removeAll();

        $.post("/agents/agentlist", data, function (result) {
            var jsonColl = JSON.parse(result);

            for (var i = 0; i <jsonColl.length; i++) {
                self.agents.push(jsonColl[i]);
            }
        });
    }
}

ko.applyBindings(new AppViewModel());
