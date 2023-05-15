function getDeptservices(url, id, tagId) {

    let data = { "id": id };
    let list = [];
    let list1 = [];
    jQuery.ajax({
        type: 'GET',
        url: url,
        data: data,
        cache: false,
        success: function (repo) {
            let item = '';
            for (let i = 0; i < repo.length; i++) {

            
           
               

                 
             
                //if (list.indexOf(repo[i].name) === -1) {

                    console.log("value exsit");
                    list1 = list;
                item += "<div class='col-10' id='inpu-deptservec'><input class='form-control' type ='text' readonly value='" + repo[i].name + " '>  </div><div class='col-1'> <input class='form-check-input checkboxc' name='DepartmentServiceId' value='"+repo[i].id+"' type='checkbox' readonly>    </div>";
                   /* list1.push(item);*/
                    $(tagId).html(item);
                  
                    list = [];
                //} else {
                //    console.log("value not exsit");
                   
             //   }
              
               
               
            }
           


        },



        error: function (ex) {

            console.log(ex.responseText);

        }
    });
}