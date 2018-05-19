  var tableId = 0;
  var tables = [];

  function addTable() {	
	tableId++;
	var table = {Id:tableId, Left:0, Top:0}
	tables.push(table);
	$(".restaurant").append("<div id='"+tableId+"' class='table' class='ui-widget-content' ondblclick='deleteTable(event)'></div>");
	$(".table").draggable();	
    $(".table").on("dragstop", function (event, ui) { 					        
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
          url: "SaveRestaurantTablesSet",
          dataType: "json",
          contentType: "application/json; charset=utf-8",
          data:things = JSON.stringify({ 'tables': tables }),
          success: function (data) {
              console.log("sssss");
          },
          failure: function (errMsg) {
              console.log("ffffffff");
          }
      });
  }
 
  function deleteTable(event) {
	var id = event.target.id;	 
    var table = $("#" + id + ".table");	
    var tableIndex = tables.findIndex(t => t.Id == id);
    delete tables[tableIndex];
    $(table).remove();		
  }