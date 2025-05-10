document.addEventListener('DOMContentLoaded', function () {
    // Sélectionner le conteneur d'image
    var imageContainer = document.querySelector('#visuelBtn');
    const imageEdit = document.querySelector('#image');
    const fileInput = document.querySelector('#fileInput');
    const preview = document.querySelector('#preview');
    if (imageContainer) {
        imageContainer.addEventListener('click', function () {
            // Déclencher le clic sur l'input file
            fileInput.click();
        });
    }
    if (imageEdit) {
        imageEdit.addEventListener('click', function () {
            // Déclencher le clic sur l'input file
            fileInput.click();
        });
    }

    // Gérer la sélection de fichier
    fileInput.addEventListener('change', function () {
        if (fileInput.files && fileInput.files[0]) {
            const file = fileInput.files[0];
            const reader = new FileReader();
            // Vérifier si le fichier est une image
            if (!file.type.match('image.*')) {
                alert('Veuillez sélectionner une image valide');
                return;
            }
            // Vérifier la taille du fichier (max 5 MB)
            if (file.size > 5 * 1024 * 1024) {
                alert('L\'image est trop volumineuse. Veuillez sélectionner une image de moins de 5 Mo.');
                return;
            }

            reader.onload = function (e) {
                preview.src = reader.result;
                if (imageContainer) {

                    imageContainer.remove();
                    preview.nextElementSibling.remove();
                    imageContainer = null;
                }
                //const img = document.createElement('img');
                //img.src = e.target.result;
                //img.style.maxWidth = '100px';
                //img.style.marginLeft = '10px';
                //img.id="image";
                //preview.appendChild(img);
            }

            reader.readAsDataURL(file);
        }
    });

});