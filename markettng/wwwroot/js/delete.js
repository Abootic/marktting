import { routting } from "./routting.js";
export function getRemove(id, url, redirect) {

    //let url = "../Facility/Delete";
   let data = { "id": id };
    Swal.fire({
        title: 'Are you sure?',
        text: "You won't be able to revert this!",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Yes, delete it!'
    }).then((result) => {
        if (result.isConfirmed) {
            let done = remove(data, url,redirect);
            if (done) {
                Swal.fire(
                    'Deleted!',
                    'Your data has been deleted.',
                    'danger'
                )
            } else {
                Swal.fire(
                    'Deleted!',
                    'Your file has been deleted.',
                    'success'
                )
            }
           
        }
    });
   
}
function remove(data, url,redirect) {
    let check = false;
    jQuery.ajax({
        type: 'GET',
        url: url,
        data: data,
        beforeSend: function () {


            $("#page").html("<div style='width: 8rem; height: 8rem; position: fixed;  left: 39%; top: 44%;font-size: 2rem;' class='spinner-border text-info' role='status'> </div>");
        },
        success: function (repo) {

            check = !check;
            routting(redirect, true);
            toastr.success(repo);
        },



        error: function (ex) {
            toastr.error(er.responseText);
            console.log(ex.responseText);

        }

    });
    return check;
}