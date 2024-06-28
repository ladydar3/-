import json 

with open('info.json', 'r', encoding='utf-8') as file:
    data = json.load(file)

student_code = "S001"
student_grades = [entry['grade'] for entry in data['study_plan'] if entry['student_code'] == student_code]

excellent_count = student_grades.count(5)
good_count = student_grades.count(4)
satisfactory_count = student_grades.count(3)

total_grades = len(student_grades)

if total_grades != 0:
    excellent_percentage = (excellent_count / total_grades) * 100
    good_percentage = (good_count / total_grades) * 100
    satisfactory_percentage = (satisfactory_count / total_grades) * 100
else:
    excellent_percentage = good_percentage = satisfactory_percentage = 0

print("Дисциплины студента с кодом", student_code, "и их оценки:", student_grades)
print("Процент оценок 'отлично':", excellent_percentage)
print("Процент оценок 'хорошо':", good_percentage)
print("Процент оценок 'удовлетворительно':", satisfactory_percentage)

answer = input("Вы хотите исправить оценку для студента с кодом "+student_code+"? (да/нет): ")

if answer.lower() == "да":
    new_grade = int(input("Введите новую оценку: "))
    for entry in data['study_plan']:
        if entry['student_code'] == student_code:
            entry['grade'] = new_grade
    with open('info.json', 'w', encoding='utf-8') as file:
        json.dump(data, file, ensure_ascii=False)
    print("Оценка студента", student_code, "была успешно изменена.")
else:
    print("Информация оценках остается без изменений.")
