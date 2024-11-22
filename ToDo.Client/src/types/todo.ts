export enum Priority {
    Low = 0,
    Medium = 1,
    High = 2,
    Critical = 3
}

export interface Todo {
    id: string;
    title: string;
    description: string;
    isCompleted: boolean;
    priority: Priority;
    createdAt: string;
    updatedAt: string;
}