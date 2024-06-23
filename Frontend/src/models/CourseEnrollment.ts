export interface CourseEnrollment {
    id?: number;
    courseId: number;
    studentId?: number;
    name: string;
    status?: number;
    startDate: string;
    endDate: string;
  }