/**
 *
 * You can write your JS code here, DO NOT touch the default style file
 * because it will make it harder for you to update.
 *
 */

"use strict";

//FormOnFail
function FormOnFail(error) {

    var response = error.responseText.replace(/"/gm, "").replace(/#/gm, "\n");
    console.log(response);

    if (error.status === 500) {
        swal("Erro", response, "error");
    }
    //if (error.status === 400) {
    //    swal("Atenção", response, "info");
    //}
}