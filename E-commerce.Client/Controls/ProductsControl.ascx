<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ProductsControl.ascx.cs" Inherits="E_commerce.Client.Controls.WebUserControl1" %>
<script src="../Scripts/jquery-3.4.1.min.js"></script>
<link href="../Layouts/TableStyle.css" rel="stylesheet" />
<script type="text/javascript">
    $(document).ready(function () {
        var urlParams = new URLSearchParams(window.location.search);
        var productId = urlParams.get('parameter');
        var productCategory = document.getElementById("category");
        var selectedOptionValue = null;

        productCategory.addEventListener("change", function () {
            selectedOptionValue = productCategory.value;
            addCustomFields(selectedOptionValue);
        });

        function addCustomFields(selectedOptionValue) {
            var customForm = document.getElementById("CustomForm");
            switch (selectedOptionValue) {
                case "laptops":
                    customForm.innerHTML = "<label for='CPU'>CPU:</label>" + 
                        "<input type='text' id='CPU' name='CPU' required class='form-control'><br>" +

                        "<label for='GPU'>GPU:</label>" +
                        "<input type='text' id='GPU' name='GPU' required class='form-control'><br>" +

                        "<label for='RAM'>RAM Memory</label>" +
                        "<input type='text' id='RAM' name='RAM' required class='form-control'><br>" +

                        "<label for='ROM'>Storage:</label>" +
                        "<input type='text' id='ROM' name='ROM' required class='form-control'><br>" +
                            
                        "<label for='Diagonala'>Display Diagonal</label>" +
                        "<input type='text' id='Diagonala' name='Diagonala' required class='form-control'><br>" +
                        
                        "<label for='Refresh'>Refresh Rate</label>" +
                        "<input type='text' id='Refresh' name='Refresh' required class='form-control'><br>" +
                        
                        "<label for='Rezolutie'>Resolution</label>" +
                        "<input type='text' id='Rezolutie' name='Rezolutie' required class='form-control'><br>" +
                        
                        "<label for='Conectivity'>Conectivity and Ports</label>" +
                        "<input type='text' id='Conectivity' name='Conectivity' required class='form-control'>";
                    break;
                case "monitors":
                    customForm.innerHTML = "<label for='Diagonala'>Display Diagonal</label>" +
                        "<input type='text' id='Diagonala' name='Diagonala' required class='form-control'><br>" +

                        "<label for='refresh'>Refresh Rate</label>" +
                        "<input type='text' id='Refresh' name='Refresh' required class='form-control'><br>" +

                        "<label for='Rezolutie'>Resolution</label>" +
                        "<input type='text' id='Rezolutie' name='Rezolutie' required class='form-control'><br>" +

                        "<label for='Conectivity'>Conectivity and Ports</label>" +
                        "<input type='text' id='Conectivity' name='Conectivity' required class='form-control'><br>" +

                        "<label for='Display'>Display Tehnology</label>" +
                        "<input type='text' id='Display' name='Display' required class='form-control'>";
                    break;
                case "smartphones":
                    customForm.innerHTML = "<label for='Diagonala'>Display Diagonal</label>" +
                        "<input type='text' id='Diagonala' name='Diagonala' required class='form-control'><br>" +

                        "<label for='Refresh'>Refresh Rate</label>" +
                        "<input type='text' id='Refresh' name='Refresh' required class='form-control'><br>" +

                        "<label for='Rezolutie'>Resolution</label>" +
                        "<input type='text' id='Rezolutie' name='Rezolutie' required class='form-control'><br>" +

                        "<label for='Conectivity'>Conectivity and Ports</label>" +
                        "<input type='text' id='Conectivity' name='Conectivity' required class='form-control'><br>" +

                        "<label for='CPU'>CPU:</label>" +
                        "<input type='text' id='CPU' name='CPU' required class='form-control'><br>" +
                        
                        "<label for='RAM'>RAM Memory</label>" +
                        "<input type='text' id='RAM' name='RAM' required class='form-control'><br>" +

                        "<label for='ROM'>Storage:</label>" +
                        "<input type='text' id='ROM' name='ROM' required class='form-control'><br>" +
                        
                        "<label for='Camera'>Camera Specifications:</label>" +
                        "<input type='text' id='Camera' name='Camera' required class='form-control'>";
                    break;
                case "refrigerators":
                    customForm.innerHTML = "<label for='Height'>Height</label>" +
                        "<input type='text' id='Height' name='Height' required class='form-control'><br>" +

                        "<label for='Width'>Width</label>" +
                        "<input type='text' id='Width' name='Width' required class='form-control'><br>" +

                        "<label for='Depth'>Depth</label>" +
                        "<input type='text' id='Depth' name='Depth' required class='form-control'><br>" +

                        "<label for='EConsumption'>Energy Consumption</label>" +
                        "<input type='text' id='EConsumption' name='EConsumption' required class='form-control'><br>" +

                        "<label for='EClass'>Energy Class</label>" +
                        "<input type='text' id='EClass' name='EClass' required class='form-control'><br>" +

                        "<label for='Noise'>Noise Level</label>" +
                        "<input type='text' id='Noise' name='Noise' required class='form-control'><br>" +

                        "<label for='Volume'>Volume:</label>" +
                        "<input type='text' id='Volume' name='Volume' required class='form-control'>";                 
                    break;
                case "washing_machines":
                    customForm.innerHTML = "<label for='Height'>Height</label>" +
                        "<input type='text' id='Height' name='Height' required class='form-control'><br>" +

                        "<label for='Width'>Width</label>" +
                        "<input type='text' id='Width' name='Width' required class='form-control'><br>" +

                        "<label for='Depth'>Depth</label>" +
                        "<input type='text' id='Depth' name='Depth' required class='form-control'><br>" +

                        "<label for='EConsumption'>Energy Consumption</label>" +
                        "<input type='text' id='EConsumption' name='EConsumption' required class='form-control'><br>" +

                        "<label for='EClass'>Energy Class</label>" +
                        "<input type='text' id='EClass' name='EClass' required class='form-control'><br>" +

                        "<label for='Noise'>Noise Level</label>" +
                        "<input type='text' id='Noise' name='Noise' required class='form-control'><br>" +

                        "<label for='Capacity'>Load Capacity:</label>" +
                        "<input type='text' id='Capacity' name='Capacity' required class='form-control'>";
                    break;
            }
        }

        function buildCustomFieldsObject(selectedOptionValue) {
            var customFieldsObject = {};
            switch (selectedOptionValue) {
                case "laptops":
                    customFieldsObject = {
                        CPU: $("#CPU").val(),
                        GPU: $("#GPU").val(),
                        RAM: $("#RAM").val(),
                        ROM: $("#ROM").val(),
                        Diagonala: $("#Diagonala").val(),
                        Refresh: $("#Refresh").val(),
                        Rezolutie: $("#Rezolutie").val(),
                        Conectivity: $("#Conectivity").val(),
                    };
                    break;
                case "monitors":
                    customFieldsObject = {
                        Diagonala: $("#Diagonala").val(),
                        Refresh: $("#Refresh").val(),
                        Rezolutie: $("#Rezolutie").val(),
                        Conectivity: $("#Conectivity").val(),
                        Display: $("#Display").val(),
                    };                    
                    break;
                case "smartphones":
                    customFieldsObject = {
                        Diagonala: $("#Diagonala").val(),
                        Refresh: $("#Refresh").val(),
                        Rezolutie: $("#Rezolutie").val(),
                        Conectivity: $("#Conectivity").val(),
                        CPU: $("#CPU").val(),
                        RAM: $("#RAM").val(),
                        ROM: $("#ROM").val(),
                        Camera: $("#Camera").val(),                        
                    };                    
                    break;
                case "refrigerators":
                    customFieldsObject = {
                        Height: $("#Height").val(),
                        Width: $("#Width").val(),
                        Depth: $("#Depth").val(),
                        EConsumption: $("#EConsumption").val(),
                        EClass: $("#EClass").val(),
                        Noise: $("#Noise").val(),
                        Volume: $("#Volume").val(),
                    };
                    break;
                case "washing_machines":
                    customFieldsObject = {
                        Height: $("#Height").val(),
                        Width: $("#Width").val(),
                        Depth: $("#Depth").val(),
                        EConsumption: $("#EConsumption").val(),
                        EClass: $("#EClass").val(),
                        Noise: $("#Noise").val(),
                        Capacity: $("#Capacity").val()
                    };                    
                    break;
            }
            return customFieldsObject;
        }

        function fillCustomFields(specifications) {
            const obj = JSON.parse(specifications);
            var customForm = document.getElementById("CustomForm");
            for (let key in obj) {
                customForm.innerHTML = customForm.innerHTML + "<label for='" + key + "'>" + key + ":</label>" +
                    "<input type='text' id='" + key + "' name='" + key + "' required class='form-control'><br>";
            }
            for (let key in obj) {
                $("#" + key).val(obj[key]);
            }
        }

       
        if (productId != null) {
            var productButton = document.getElementById("addProduct");
            productButton.textContent = "Edit Product"
            // Pre-fill data with previous data 
            $.ajax({
                url: "https://localhost:44343/api/products/" + productId,
                type: "GET",
                dataType: "json",
                success: function (data) {
                    $("#user_id").val(data.User_ID);
                    $("#name").val(data.Name);
                    $("#price").val(data.Price);
                    $("#description").val(data.Description);
                    $("#image").val(data.Image);
                    $("#category").val(data.Category);
                    fillCustomFields(data.Specifications);                                  
                },
                error: function () {
                    // Handle error
                }
            });
            
            $("#addProduct").click(function () {
                var updateCustomObject = buildCustomFieldsObject($("#category").val());
                var formData = {
                    User_ID: $("#user_id").val(),
                    Name: $("#name").val(),
                    Price: $("#price").val(),
                    Description: $("#description").val(),
                    Image: $("#image").val(),
                    Category: $("#category").val(),
                    Specifications: JSON.stringify(updateCustomObject)
                };                

                $.ajax({
                    url: "https://localhost:44343/api/products/" + productId,
                    type: "PUT",
                    contentType: "application/json",
                    data: JSON.stringify(formData),
                    success: function () {
                        window.location.href = "Products.aspx";
                    },
                    error: function () {
                        window.location.href = "Products.aspx";
                    }
                });
            });

        } else {
            var productButton = document.getElementById("addProduct");
            productButton.textContent = "Add Product"
            // Handle add button click
            $("#addProduct").click(function () {
                var customObject = buildCustomFieldsObject(selectedOptionValue);

                var formData = {
                    User_ID: $("#user_id").val(),
                    Name: $("#name").val(),
                    Price: $("#price").val(),
                    Description: $("#description").val(),
                    Image: $("#image").val(),
                    Category: $("#category").val(),
                    Specifications: JSON.stringify(customObject)
                };

                $.ajax({
                    url: "https://localhost:44343/api/products",
                    type: "POST",
                    contentType: "application/json",
                    data: JSON.stringify(formData),
                    success: function () {
                        console.log("Product added successfully.");
                        clearForm();
                        location.reload(); 
                    },
                    error: function () {
                        console.log("Error adding user.");
                    }
                });
            });

            function clearForm() {
                $("#user_id").val("");
                $("#name").val("");
                $("#price").val("");
                $("#description").val("");
                $("#image").val("");
                $("#category").val("");
            }
        }
    });


</script>

<div id="IdRegistrationForm" runat="server" class="field form-group">
    <label for="user_id1">User ID:</label>
    <input type="text" id="user_id" name="user_id" required class="form-control"><br>

    <label for="name1">Name:</label>
    <input type="text" id="name" name="name" required class="form-control"><br>

    <label for="price1">Price:</label>
    <input type="number" id="price" name="price" required class="form-control"><br>

    <label for="description1">Description:</label>
    <input type="text" id="description" name="description" required class="form-control"><br>

    <label for="image1">Image:</label>
    <input type="file" id="image" name="image" accept="image/*" class="form-control"><br>



    <label for="category">Category:</label>
    <select typeof="text" id="category" name="category" required class="form-control">
        <option>Select Category</option>
        <option value="laptops">Laptops</option>
        <option value="monitors">Monitors</option>
        <option value="smartphones">Smartphones</option>
        <option value="refrigerators">Refrigerators</option>
        <option value="washing_machines">Washing Machines</option>
    </select><br>

    <div id="CustomForm" class="field form-group">      
    </div>

    <br>

    <button type="button" id="addProduct" class="btn btn-secondary rounded-3">Add Product</button>
</div>
<p></p>
