import { useState, useEffect } from 'react';
import { Formik, Form, Field, ErrorMessage } from 'formik';
import * as Yup from 'yup';
import { Course } from '../models/Course';
import { Student } from '../models/Student';
import { CourseEnrollment } from '../models/CourseEnrollment';
import { Dropdown } from '../components/Dropdown';

function StudentEnrollmentView() {
    const [courses, setCourses] = useState<Course[]>([]);
    const [selectedCourses, setSelectedCourses] = useState<Course[]>([]);

    useEffect(() => {
        fetch('http://localhost:5089/course/getcourses')
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
    
            return [...prev, course];
        });
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

    const validationSchema = Yup.object({
        firstName: Yup.string().required('First name is required'),
        lastName: Yup.string().required('Last name is required'),
        email: Yup.string().email('Invalid email address').required('Email is required'),
    });

    const handleSubmit = (values: Student) => {
        const studentEnrollment: Student = {
            ...values,
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

    return (
        <div>
            <Formik
                initialValues={initialValues}
                validationSchema={validationSchema}
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
