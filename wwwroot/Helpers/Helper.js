
var Upload = {

    UploadDefaultImg: function (e) {

        const file = e.target.files[0];
        const reader = new FileReader();
        reader.onloadend = () => {


            CourseMediaImgName = file.name;
            CourseMediaImgBase64 = reader.result.slice(reader.result.indexOf('base64,') + 7);
            $("#tbImgName").html(file.name);
            $("#tbImgSrc").html(`<img class= "thumbnail" src = "${reader.result}" style="width: 50%; height:50%; border-radius: 5px; border:1px solid black; padding: 1px;"/>`);

        };
        reader.readAsDataURL(file);


    }

}