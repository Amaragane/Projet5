document.addEventListener('DOMContentLoaded', function () {
    // Sélectionner le conteneur d'image
    const imageContainer = document.querySelector('#visuelBtn');
    const fileInput = document.querySelector('#fileInput');
    const preview = document.querySelector('#preview');
    if (!imageContainer || !fileInput) return;

    // Ajouter un gestionnaire d'événements au conteneur d'image
    imageContainer.addEventListener('click', function () {
        // Créer un input de type file temporaire        
        // Déclencher le clic sur l'input file
        fileInput.click();
    });
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

            // Simuler un téléchargement d'image et obtenir une URL
            // Dans un cas réel, vous utiliseriez une API pour télécharger l'image sur le serveur
            // Pour cette démonstration, nous utiliserons FileReader pour une prévisualisation locale

            reader.onloadend = function (e) {
                preview.innerHTML = "";
                
                const img = document.createElement('img');
                img.src = e.target.result;
                img.style.maxWidth = '100px';
                img.style.marginLeft = '10px';
                preview.appendChild(img);
            }

            reader.readAsDataURL(file);
        }
    }); 
});