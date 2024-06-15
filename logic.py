import random
import os   

class EnigmaGame:
    def __init__(self):
        self.score = 0
        self.current_image = None
        self.current_object = None
        self.attempts = 0
        self.objects = []

    def load_image(self, image_name):
        # Obtém o caminho completo da imagem
        self.current_image = self.get_image_path(image_name)
        self.objects = self.generate_objects()
        self.next_object()

    def get_image_path(self, image_name):
        # Assume que as imagens estão em uma pasta chamada "images"
        base_path = "images"
        full_path = os.path.join(base_path, image_name)
        if not os.path.exists(full_path):
            raise FileNotFoundError(f"Imagem não encontrada: {full_path}")
        return full_path
    
    def generate_objects(self):
        # Gerar objetos e textos enigmáticos
        return [
            {"name": "object1", "hint": "Este é o objeto 1."},
            {"name": "object2", "hint": "Este é o objeto 2."},
            {"name": "object3", "hint": "Este é o objeto 3."},
            {"name": "object4", "hint": "Este é o objeto 4."},
            {"name": "object5", "hint": "Este é o objeto 5."}
        ]

    def next_object(self):
        if self.objects:
            self.current_object = self.objects.pop(0)
            self.attempts = 0
            return self.current_object["hint"]
        else:
            return None

    def check_guess(self, guess):
        if guess == self.current_object["name"]:
            if self.attempts == 0:
                self.score += 10
            else:
                self.score += 5
            return True
        else:
            self.attempts += 1
            if self.attempts >= 2:
                return False
            else:
                return "Try again"

    def get_score(self):
        return self.score
