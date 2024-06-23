import { CourseEnrollment } from "./CourseEnrollment";

export interface Student {
    id?: number;
    firstName: string;
    lastName: string;
    email: string;
    status?: number;
    courseEnrollments: CourseEnrollment[];
  }