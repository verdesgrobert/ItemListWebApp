(function () {
    var itemHub = $.connection.itemHub;

    var updateItemsRetrievedByClient = function (items) {
        console.log("Items obtained by client: " + items.length.toString());
        $("#item-list").empty();
        for (var i = 0; i < items.length; i++) {
            $("#item-list").append("From client: " + items[i] + "<br/>");
        }
    };

    var updateItemsPushedFromServer = function (items) {
        console.log("Items received from server: " + items.length.toString());
        $("#item-list").empty();
        for (var i = 0; i < items.length; i++) {
            $("#item-list").append("From server: " + items[i] + "<br/>");
        }
    };

    $("#submit").on("click",
        function () {
            var text = $("#textname").val();
            itemHub.server.addItem(text)
                .done(function() {
                    console.log("Adding item: " + text);
                })
                .fail(function(e) {
                    console.log(e);
                });

            itemHub.server.getItems()
                .done(function (items) {
                    updateItemsRetrievedByClient(items);
                })
                .fail(function(e) {
                    console.log(e);
                });
        });

    $.connection.hub.start()
        .done(function () {
            console.log("Connected to SignalR hub");
        })
        .fail(function (e) { console.log(e) });

    itemHub.client.itemListUpdated = updateItemsPushedFromServer;
})()