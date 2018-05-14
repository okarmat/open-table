
  
  function addTable(){
	$(".restaurant").append("<div class='draggable' class='ui-widget-content'></div>")
	$(".draggable").draggable();
	$(".draggable").on( "dragstop", function( event, ui ) { console.log(ui.position);} );
	$(".draggable").draggable({
		drag: function( event, ui ) {
		//console.log(ui.position);
		}
	});
  }
  
  function createLogInfo(){

  }
  
$( ".draggable" ).draggable({
  drag: function( event, ui ) {}
});

