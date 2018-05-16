  var tableId = 0;
  var tables = [];

  function addTable(){	
	tableId++;
	var table = {id:tableId, left:0, top:0}
	tables.push(table);
	$(".restaurant").append("<div id='"+tableId+"' class='table' class='ui-widget-content' ondblclick='deleteTable()'></div>");
	$(".table").draggable();	
    $(".table").on( "dragstop", function( event, ui) { 					
		saveTablePosition(Number($(this).attr("id")), ui.position.left, ui.position.top);
	});	
  }
  
  function saveTablePosition(id, left, top) {
		console.log(tables.findIndex(t => t.id === id))
		var tableIndex = tables.findIndex(t => t.id === id);
		tables[tableIndex].left = left;
		tables[tableIndex].top = top;
  }
 
  function deleteTable() {
	var del = $('#1.table');
	console.log(del);
    $(del).remove();		
  }