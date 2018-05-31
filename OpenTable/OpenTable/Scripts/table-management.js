var tableMaxId = 0;
var tables = [];
var reservedTable = 0;

function initTableManagementView(initialTableMaxId, initialTables) {
      tableMaxId = initialTableMaxId;
      tables = JSON.parse(initialTables);
    
      tables.forEach(function (element) {
          $(".restaurant").append("<div id='" + element.Id + "' class='restaurant-table' class='ui-widget-content'></div>");
          $("#" + element.Id + ".restaurant-table").draggable();
          $("#" + element.Id + ".restaurant-table").css({ 'top': element.Top, 'left': element.Left });
          $(".restaurant-table").on("dragstop", function (event, ui) {
              saveTablePosition(Number($(this).attr("id")), ui.position.left, ui.position.top);
          });
      });   
}

function initTableReservationView(initialTables) {
    tables = JSON.parse(initialTables);

    tables.forEach(function (element) {
        $(".restaurant").append("<div id='" + element.Id + "' class='restaurant-table' class='ui-widget-content'></div>");
        $("#" + element.Id + ".restaurant-table").draggable();
        $("#" + element.Id + ".restaurant-table").css({ 'top': element.Top, 'left': element.Left });

        if (element.Reserved) {
            $("#" + element.Id + ".restaurant-table").toggleClass("reserved-by-someone");
        }
        else {
            $("#" + element.Id + ".restaurant-table").click(function () {
                var tableId = Number($("#TableId").val());
                if (tableId === element.Id) {
                    $("#TableId").val(0);
                    $("#ReserveBtn").prop('disabled', true);
                    $("#" + element.Id + ".restaurant-table").toggleClass("reserved-by-me");
                }
                else if (tableId === 0) {
                    $("#TableId").val(element.Id);
                    $("#ReserveBtn").prop('disabled', false);
                    $("#" + element.Id + ".restaurant-table").toggleClass("reserved-by-me");
                }
                else {
                    alert("You can reserve only one table for reservation.");
                }
            });
        }
    });

    $(".restaurant-table").draggable("disable");
}

function updateReservationStatus() {
    console.log("on focus out event");
}

function addTable(restaurantId) {	
    tableMaxId++;
    var table = { Id: tableMaxId, RestaurantId: restaurantId, Left: 0, Top: 0 };
	tables.push(table);
    $(".restaurant").append("<div id='" + tableMaxId+"' class='restaurant-table' class='ui-widget-content'></div>");
    $(".restaurant-table").draggable();	
    $(".restaurant-table").on("dragstop", function (event, ui) { 					        
        saveTablePosition(Number($(this).attr("id")), ui.position.left, ui.position.top);
	});	
}
  
function saveTablePosition(id, left, top) {
		var tableIndex = tables.findIndex(t => t.Id === id);
		tables[tableIndex].Left = left;
        tables[tableIndex].Top = top;
}

function saveTablesSet() {
      jQuery.ajax({
          type: "POST",
          url: "/Restaurants/SaveTablesSet",
          dataType: "json",
          contentType: "application/json; charset=utf-8",
          data: things = JSON.stringify({ 'tables': tables })
      });
      window.location = '/Restaurants/Index';
}
 
function deleteAllTables() {
      if (confirm('Are you sure you want to delete all tables?')) {
          tables.forEach(function (element) {
              var tableIndex = tables.findIndex(t => t.Id === element.Id);
              tables[tableIndex].Erase = true;
              $("#" + element.Id + ".restaurant-table").remove();
          });	
      } 
}