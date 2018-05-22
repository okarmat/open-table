var tableMaxId = 0
var tables = [];

function initTableManagementView(initialTableMaxId, initialTables) {
      tableMaxId = initialTableMaxId;
      tables = JSON.parse(initialTables);

      tables.forEach(function (element) {
          $(".restaurant").append("<div id='" + element.Id + "' class='restaurant-table' class='ui-widget-content' ondblclick='deleteTable(event)'></div>");
          $("#" + element.Id + ".restaurant-table").draggable();
          $("#" + element.Id + ".restaurant-table").css({ 'top': element.Top, 'left': element.Left })
          $(".restaurant-table").on("dragstop", function (event, ui) {
              saveTablePosition(Number($(this).attr("id")), ui.position.left, ui.position.top);
          });	
      })
  }

  function addTable(restaurantId) {	
    tableMaxId++;
    var table = { Id: tableMaxId, RestaurantId: restaurantId, Left:0, Top:0, Erase:false }
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
              var tableIndex = tables.findIndex(t => t.Id == element.Id);
              tables[tableIndex].Erase = true;
              $("#" + element.Id + ".restaurant-table").remove();
          })	
      } 
  }