  var tableId = 0;
  var tables = [];

  function addTable(){	
	tableId++;
	var table = {id:tableId, left:0, top:0}
	tables.push(table);
	$(".restaurant").append("<div id='"+tableId+"' class='draggable' class='ui-widget-content'></div>");
	$(".draggable").draggable();	
    $(".draggable").on( "dragstop", function( event, ui) { 					
		saveTablePosition(Number($(this).attr("id")), ui.position.left, ui.position.top);
	});	
  }
  
  function saveTablePosition(id, left, top) {
		console.log(tables.findIndex(t => t.id === id))
		var tableIndex = tables.findIndex(t => t.id === id);
		tables[tableIndex].left = left;
		tables[tableIndex].top = top;
  }
 
