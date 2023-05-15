
import { routting } from "./routting.js";

function confirmPass() {
    // $(document).ready(function () {
    let pass = $("#pass").val();
         let confirmPass = $("#confirm-pass").val();
       
    
    //if (confirmPass.length > 5) {
    if (confirmPass == pass) {
        console.log("00000000000000000");
            return true;
    } else {
       
            return false;
        }
    //}
    //});
}
//////////////////////////////////////////////////////////////////

// start registeruser


export function post(url, tagId, check,redirect) {

    let data = new FormData(document.getElementById(tagId));
    let run = true;
    //if (check) {
    //    let confirm = confirmPass();
        
    //    if (confirm) {
    //         run = true;
    //    } else {
    //        run = !run;
    //        $("#sconfirm-message").html("<span class='text-danger'> كلمات المرور لاتتطابق</span>");
    //    }
    //}
   // if (run) {

    
    jQuery.ajax({
        method: "post",
        url: url,
        data: data,
        processData: false,
        contentType: false,
       // cache: false,
        statusCode: {
            400: function (e) {

                console.log("4000000000000  "+e.responseText);


            }
        },
        beforeSend: function () {
            
            $(".send-btn").html("<span class='spinner-border spinner-border-sm' role='status' aria-hidden='true'> </span>Loading...");
            $(".send-btn").prop("disabled", true);
        },
        success: function (repo) {

            $(".send-btn").prop("disabled", false);
            $(".send-btn").html("اضافة");

            Swal.fire({
                position: 'top-end',
                icon: 'success',
                title: 'تم الاضافة بنجاح',
                showConfirmButton: false,
                timer: 1500
            });
            if (redirect == "null") {
                $("#page").html(repo);
            } else { routting(redirect, true); }
            $("#page").html(repo);
         
           
        },
        error: function (er) {
           
            
            $(".send-btn").html("اضافة");

       
            $(".send-btn").prop("disabled", false);
            toastr.error(er.responseText);
        }

    });
    //}
}export function postReport(url, tagId) {

    let data = new FormData(document.getElementById(tagId));
    
   // if (run) {

    
    jQuery.ajax({
        method: "post",
        url: url,
        data: data,
        processData: false,
        contentType: false,
        beforeSend: function () {
         $("#page").html("  <div style='width: 8rem; height: 8rem; position: fixed;  left: 39%; top: 44%;font-size: 2rem;' class='spinner-border text-info' role='status'> </div>");
        },
      
        success: function (repo) {

           // $("#print-page").html(repo);
            $("#page").html(repo);
            document.getElementById("page").removeAttribute("class");
            document.getElementById("bodyContentId").removeAttribute("class");
            window.print();

               
          
         
           
        },
        error: function (er) {
            toastr.error(er.responseText);
            
            $(".send-btn").html("طباعة");

       
            $(".send-btn").prop("disabled", false);
        }

    });
    //}
   
}
