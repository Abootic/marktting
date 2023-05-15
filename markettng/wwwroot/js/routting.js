


/////////// go to user
export  function routting(url,check) {
 
    jQuery.ajax({
        type: 'Get',
        url: url,
        cache: false,
        statusCode: {
            401: function (e) {
             
                $("#body").html("<div class='alert alert-danger'>ليس لديك الصلاحية  </div>");


            }
        },
        beforeSend: function () {

         
            $("#page").html("  <div style='width: 8rem; height: 8rem; position: fixed;  left: 39%; top: 44%;font-size: 2rem;' class='spinner-border text-info' role='status'> </div>");
        },
      
        success: function (repo) {

           
          
            document.getElementById("show-drawer").classList.replace("list-toggler", "list-container");
            document.getElementById("page").setAttribute("class", "flex-wrap");
            document.getElementById("bodyContentId").setAttribute("class", "bodyContent");
            $("#page").html(repo);
        
            
            
        },

        error: function (ex) { document.getElementById("error").innerHTML = ex.responseText; }
    });
}
