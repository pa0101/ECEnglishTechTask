import React, { useState, useEffect } from 'react';
import { Course } from '../models/Course';
import { Student } from '../models/Student';
import { CourseEnrollment } from '../models/CourseEnrollment';
import { Dropdown } from '../components/Dropdown';

function StudentEnrollmentView() {
    const [courses, setCourses] = useState<Course[]>([]);
    const [selectedCourses, setSelectedCourses] = useState<Course[]>([]);
    const [student, setStudent] = useState<Student>({
        firstName: '',
        lastName: '',
        email: '',
        courseEnrollments: []
    });

    useEffect(() => {
        fetch('http://localhost:5089/course/getcourses')
            .then(response => response.json())
            .then(data => setCourses(data))
            .catch(error => console.error('Error fetching courses:', error));
    }, []);

    const handleCourseSelect = (course: Course) => {
        setSelectedCourses(prev => [...prev, course]);
    };

    const handleInputChange = (e: React.ChangeEvent<HTMLInputElement>) => {
        const { name, value } = e.target;
        setStudent(prev => ({ ...prev, [name]: value }));
    };

    const handleSubmit = () => {
        const studentEnrollment: Student = {
            ...student,
            courseEnrollments: mapCourseEnrollments(selectedCourses)
        };

        fetch('http://localhost:5089/student/addstudent', {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify(studentEnrollment)
        })
        .then(response => response.json())
        .then(data => console.log('Success:', data))
        .catch(error => console.error('Error:', error));
    };

    const mapCourseEnrollments = (courses: Course[]): CourseEnrollment[] => {
        return courses.map((course) => ({
            courseId: course.id,
            name: course.name,
            startDate: course.startDate,
            endDate: course.endDate
        }));
    };

    return (
        <div>
            <h1>Student Enrollment Form</h1>
            <Dropdown<Course>
                items={courses}
                labelKey="name"
                valueKey="id"
                onSelect={handleCourseSelect}
                defaultOption="Select Courses"
            />
            <div>
                <label>
                    First Name:
                    <input type="text" name="firstName" value={student.firstName} onChange={handleInputChange} />
                </label>
            </div>
            <div>
                <label>
                    Last Name:
                    <input type="text" name="lastName" value={student.lastName} onChange={handleInputChange} />
                </label>
            </div>
            <div>
                <label>
                    Email:
                    <input type="email" name="email" value={student.email} onChange={handleInputChange} />
                </label>
            </div>
            <button onClick={handleSubmit}>Submit Enrollment</button>
        </div>
    );
};

export default StudentEnrollmentView;