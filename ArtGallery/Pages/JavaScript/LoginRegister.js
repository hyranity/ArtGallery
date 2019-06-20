$(document).ready(function () {
	$("#register").mouseover(function () {
		$("#login").css("opacity", "0.3"); // Disables an entire section
		$("#register").css("opacity", "1");
		$("#login input").prop("disabled", true);
		$("#register input").prop("disabled", false);
	});
	$("#login").mouseover(function () {
		$("#login").css("opacity", "1");
		$("#register").css("opacity", "0.3");
		$("#register input").prop("disabled", true);
		$("#login input").prop("disabled", false);
	});
});
