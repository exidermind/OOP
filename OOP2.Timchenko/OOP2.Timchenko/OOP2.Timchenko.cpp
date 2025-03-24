#include <iostream>
#include <string>
using namespace std;

class Pet {
protected:
    string name; 
    int age;

public:
    Pet() { // Конструктор по умолчанию
        name = "";
        age = 0;
        printf("Конструктор по умолчанию Pet \n");
    }

    Pet(string name, int age) { // Конструктор с параметрами
        this->name = name;
        this->age = age;
        printf("Конструктор с параметрами Pet \n");
    }

    Pet(const Pet& x) { // Конструктор копирования
        this->name = x.name;
        this->age = x.age;
        printf("Конструктор копирования Pet \n");
    }

    // Методы
    void set_name(string name) {
        this->name = name;
        printf("Метод set_name\n");
    }

    void set_age(int age) {
        this->age = age;
        printf("Метод set_age\n");
    }

    // Деструктор
    ~Pet() {
        printf("Вызвался деструктор Pet\n");
    }
};

class Dog : public Pet {
public:
    string breed; 

public:
    Dog() {
        breed = "";
        printf("Вызвался конструктор по умолчанию Dog\n");
    }

    ~Dog() {
        printf("Вызвался деструктор Dog\n");
    }
};

class Cat : public Pet {
private:
    string color;

public:
    Cat() {
        color = "";
        printf("Вызвался конструктор по умолчанию Cat\n");
    }

    void set_color(string color) {
        this->color = color;
    }

    void meow() {
        cout << "Мяу!" << endl;
    }

    ~Cat() {
        printf("Вызвался деструктор Cat\n");
    }
};

class PetShelter {
public:
    Pet Pet1;
    Pet* Pet2;

    PetShelter() {
        Pet2 = new Pet;
        printf("Вызвался конструктор по умолчанию (композиция)\n");
    }

    PetShelter(string name1, int age1, string name2, int age2) {
        Pet1.set_name(name1);
        Pet1.set_age(age1);
        Pet2 = new Pet;
        Pet2->set_name(name2);
        Pet2->set_age(age2);
        printf("Вызвался конструктор с параметрами (композиция)\n");
    }

    PetShelter(const PetShelter& copy)
        : Pet1(copy.Pet1), Pet2(new Pet(*copy.Pet2)) {
        printf("Вызвался конструктор копирования (композиция)\n");
    }

    ~PetShelter() {
        delete Pet2;
        printf("Вызвался деструктор (композиция)\n");
    }
};

// Основная функция



int main() {
    setlocale(LC_ALL, "Russian");

    Pet bobik; // По умолчанию
    Pet tuzik("Тузик", 5); // С параметрами
    Pet tuzikJr(tuzik); // Копирование

    Pet* Sharik = new Pet(); // Указатель
    delete Sharik; // Уничтожить Шарика 0.0

    bobik.set_name("Бобик");
    bobik.set_age(6);

    // delete bobik; - Не сработает, потому что на Бобика у нас ссылки нету

    printf("\n——————————————————————————————\n");

    Cat Pushinka; // Использование потомка
    Pushinka.meow(); // Его метод
    Pushinka.Pet::set_name("Пушинка"); // Использование метода предка

    printf("\n——————————————————————————————\n");
    
    PetShelter shelter("Граф", 3, "Персик", 6); // Композиция
    PetShelter shelterCopy(shelter);
    PetShelter newShelter;

    printf("\n——————————————————————————————\n");

    Pet* unnamed1 = new Pet();
    Pet* unnamed2 = new Cat();
    unnamed2->set_age(5);

    return 0;
}