import { useState, useEffect } from 'react';
import { Formik, Form, Field, ErrorMessage } from 'formik';
import { studentEnrollmentFormSchema } from '../yup/ValidationSchema';
import { Course } from '../models/Course';
import { Student } from '../models/Student';
import { CourseEnrollment } from '../models/CourseEnrollment';
import { Dropdown } from '../components/Dropdown';


function StudentEnrollmentView() {
    const [courses, setCourses] = useState<Course[]>([]);
    const [selectedCourses, setSelectedCourses] = useState<Course[]>([]);
    const [selectedCourseId, setSelectedCourseId] = useState<string | number>(''); 

    useEffect(() => {
        fetch(`${import.meta.env.VITE_API_BASE_URL}course/getcourses`)
            .then(response => response.json())
            .then(data => setCourses(data))
            .catch(error => console.error('Error fetching courses:', error));
    }, []);

    const handleCourseSelect = (course: Course) => {
        setSelectedCourses(prev => {
            if (prev.some(selectedCourse => selectedCourse.startDate === course.startDate)) {
                alert('Course dates cannot overlap!');
                return prev;
            }
            alert(`${course.name} added!`);
            return [...prev, course];
        });
        setSelectedCourseId('');
    };

    const mapCourseEnrollments = (courses: Course[]): CourseEnrollment[] => {
        return courses.map(course => ({
            courseId: course.id,
            name: course.name,
            startDate: course.startDate,
            endDate: course.endDate
        }));
    };

    const initialValues: Student = {
        id: 0,
        firstName: '',
        lastName: '',
        email: '',
        status: 0,
        courseEnrollments: []
    };

    const handleSubmit = (values: Student, { resetForm }: { resetForm: () => void }) => {
        const studentEnrollment: Student = {
            ...values,
            courseEnrollments: mapCourseEnrollments(selectedCourses)
        };

        fetch(`${import.meta.env.VITE_API_BASE_URL}student/addstudent`, {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify(studentEnrollment)
        })
            .then(response => response.json())
            .then(data => {
                let addStudentMessage = `User added!\n${data.firstName} ${data.lastName}\n${data.email}\n`;
                data.courseEnrollments.forEach((courseEnrollment: { name: CourseEnrollment; }) => {
                    addStudentMessage += `${courseEnrollment.name}\n`;
                });
                alert(addStudentMessage);
                resetForm();
                setSelectedCourses([]);
                setSelectedCourseId('');
            })
            .catch(error => console.error('Error:', error));
    };

    return (
        <div>
            <Formik
                initialValues={initialValues}
                validationSchema={studentEnrollmentFormSchema}
                onSubmit={handleSubmit}
            >
                {({ setFieldValue }) => (
                    <Form>
                        <div className="form-group">
                            <label className="label" htmlFor="courseSelect">Courses:</label>
                            <Dropdown<Course>
                                items={courses}
                                labelKey="name"
                                valueKey="id"
                                onSelect={(course) => {
                                    handleCourseSelect(course);
                                    setFieldValue('courseEnrollments', selectedCourses);
                                }}
                                selectedValue={selectedCourseId}
                                defaultOption="Select Course"
                            />
                        </div>
                        {selectedCourses.length === 0 && <div className="validation-message">Select at least one course.</div>}
                        <div className="form-group">
                            <label className="label" htmlFor="firstName">First Name:</label>
                            <Field type="text" id="firstName" name="firstName" />
                            <ErrorMessage name="firstName" component="div" />
                        </div>
                        <div className="form-group">
                            <label className="label" htmlFor="lastName">Last Name:</label>
                            <Field type="text" id="lastName" name="lastName" />
                            <ErrorMessage name="lastName" component="div" />
                        </div>
                        <div className="form-group">
                            <label className="label" htmlFor="email">Email:</label>
                            <Field type="email" id="email" name="email" />
                            <ErrorMessage name="email" component="div" />
                        </div>
                        <button type="submit" disabled={selectedCourses.length === 0}>
                            Submit
                        </button>
                    </Form>
                )}
            </Formik>
        </div>
    );
}

export default StudentEnrollmentView;
