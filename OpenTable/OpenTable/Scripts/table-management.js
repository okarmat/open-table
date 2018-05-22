var tableMaxId = 0
var tables = [];

function initTableManagementView(initialTableMaxId, initialTables) {
    console.log(initialTables);

      tableMaxId = initialTableMaxId;
      tables = JSON.parse(initialTables);

      tables.forEach(function (element) {
          $(".restaurant").append("<div id='" + element.Id + "' class='restaurant-table' class='ui-widget-content' ondblclick='deleteTable(event)'></div>");
          $("#" + element.Id + ".restaurant-table").draggable();
          $("#" + element.Id + ".restaurant-table").css({ 'top': element.Top, 'left': element.Left })
          $(".restaurant-table").on("dragstop", function (event, ui) {
              saveTablePosition(Number($(this).attr("id")), ui.position.left, ui.position.top);
              console.log(Number($(this).attr("id")), ui.position.left, ui.position.top);
          });	
      })
  }

  function addTable(restaurantId) {	
    tableMaxId++;
    var table = { Id: tableMaxId, RestaurantId: restaurantId, Left:0, Top:0, Erase:false }
	tables.push(table);
    $(".restaurant").append("<div id='" + tableMaxId+"' class='restaurant-table' class='ui-widget-content' ondblclick='deleteTable(event)'></div>");
    $(".restaurant-table").draggable();	
    $(".restaurant-table").on("dragstop", function (event, ui) { 					        
		saveTablePosition(Number($(this).attr("id")), ui.position.left, ui.position.top);
	});	
  }
  
  function saveTablePosition(id, left, top) {
		var tableIndex = tables.findIndex(t => t.Id === id);
		tables[tableIndex].Left = left;
        tables[tableIndex].Top = top;

        console.log(left, top);
  }

  function saveTablesSet() {
         jQuery.ajax({
          type: "POST",
          url: "/Restaurants/SaveTablesSet",
          dataType: "json",
          contentType: "application/json; charset=utf-8",
          data: things = JSON.stringify({ 'tables': tables }),
          complete: function () {
              console.log("s");
              window.location = '/Restaurants/Index';
          }
      });      

         console.log(tables);
  }
 
  function deleteTable(event) {
	var id = event.target.id;	 
    var table = $("#" + id + ".restaurant-table");	
    var tableIndex = tables.findIndex(t => t.Id == id);
    tables[tableIndex].Erase = true;
    $(table).remove();		
  }