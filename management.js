function addTable() {
	$( ".restaurant" ).append("<div class='table'></div>");
    
	var $tables = $('.table').draggabilly({
    containment: true
  });
}