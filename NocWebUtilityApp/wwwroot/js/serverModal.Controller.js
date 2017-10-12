//* OnSolve
//* Author: Daniel Jackson
//* NocWebUtility Application
//* Created: 03 / 22 / 2017
//* Last Edit: 09 / 22 / 2017
//* Description: Logic for the modal window which changes the servers a user selects via select box.

; (function ($) {
	var productId;
	var serverColumn;
	var serverGroup;

	/**
	* @desc Gets parameters for server call. 
	* @param  {int} productId
	* @param  {string} serverColumn
	* @param  {string} serverGroup
	*/
	$(document).ready(function () {

		$('[serverColumn]').click(function () {
			serverColumn = $(this).attr('serverColumn');
			serverGroup = $(this).attr('serverGroup'); // Used in future iteration for color grouping of servers
			productId = $(this).attr('productId');

			$('#serverModal').modal();

			$('#saveButton').click(function () {
				$('#serverModal').modal('hide');
			});
			// Keeping this seperate makes it work faster.
			$('#serverModal').on('hide.bs.modal', function () {

			});
		});
	});

	$.fn.serverListChangeFunction = function serverListChange() {
		/**
		 * @desc POST new server change when user selects.
		 * @param {int} selectedServerId
		 * @param {int[]} selectedProductIds
		 * @param {Controller} TableDataVMs
		 * @param {Action} SaveSelectedServer
		 */
		var selectedServerId = $('#ServerSelectList').val();
		var selectedProductIds = $('#ProductSelectList').val();
		var ajaxRequest = $.ajax({
			type: 'POST',
			url: 'SaveSelectedServer',
			data: {
				'productId': productId,
				'serverColumn': serverColumn,
				'serverId': selectedServerId
			},
			success: function () {
				$('#serverModal').modal('hide');
				location.reload();
			},
			error: function (status) {
				if (status.status === 401) {
					alert("Data can only be changed by admin");
				}
				else {
					alert(status.statusText + ". Please contact admin");
				}
				$('#serverModal').modal('hide');
			}
		});
	};
}(jQuery));


