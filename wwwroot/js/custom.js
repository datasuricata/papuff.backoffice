/**
 *
 * You can write your JS code here, DO NOT touch the default style file
 * because it will make it harder for you to update.
 *
 */

"use strict";

//FormOnFail
function FormOnFail(error) {
    if (error.status === 500) {
        swal("Erro", error.responseText, "error");
    }
    if (error.status === 400) {
        swal("Aten��o", error.responseText, "info");
    }
}