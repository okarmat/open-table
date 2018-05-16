  var tableId = 0;
  var tables = [];

  function addTable(){	
	tableId++;
	var table = {id:tableId, left:0, top:0}
	tables.push(table);
	$(".restaurant").append("<div id='"+tableId+"' class='table' class='ui-widget-content' ondblclick='deleteTable(event)'></div>");
	$(".table").draggable();	
    $(".table").on( "dragstop", function( event, ui) { 					
		saveTablePosition(Number($(this).attr("id")), ui.position.left, ui.position.top);
	});	
  }
  
  function saveTablePosition(id, left, top) {
		var tableIndex = tables.findIndex(t => t.id === id);
		tables[tableIndex].left = left;
		tables[tableIndex].top = top;
  }
 
  function deleteTable(event) {
	var id = event.target.id;	 
	var table = $("#"+id+".table");	
    $(table).remove();		
  }