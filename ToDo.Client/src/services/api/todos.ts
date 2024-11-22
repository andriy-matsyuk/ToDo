import { api } from '@/lib/axios';
import { PaginatedResponse } from '@/types/pagination';
import { Todo } from '@/types/todo';

export interface CreateTodoDTO {
    title: string;
    description: string;
    priority: number;
}

export interface UpdateTodoDTO extends CreateTodoDTO {
    isCompleted: boolean;
}

export interface PaginationParams {
    pageNumber: number;
    pageSize: number;
}

export const todosApi = {
    getAll: (params: PaginationParams = { pageNumber: 1, pageSize: 1000 }) => {
        const queryParams = new URLSearchParams();
        queryParams.append('PageNumber', params.pageNumber.toString());
        queryParams.append('PageSize', params.pageSize.toString());

        return api.get<PaginatedResponse<Todo>>(`api/todos?${queryParams.toString()}`);
    },

    create: (todo: CreateTodoDTO) =>
        api.post<Todo>('api/todos', todo),

    update: (id: string, todo: UpdateTodoDTO) =>
        api.put<Todo>(`api/todos/${id}`, todo),

    delete: (id: string) =>
        api.delete(`api/todos/${id}`),
};