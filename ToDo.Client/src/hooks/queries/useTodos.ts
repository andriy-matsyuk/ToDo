import { useQuery, useMutation, useQueryClient } from '@tanstack/react-query';
import { todosApi, UpdateTodoDTO } from '@/services/api/todos';

export const todoKeys = {
    all: ['todos'] as const,
    lists: () => [...todoKeys.all, 'list'] as const,
    list: (filters: string) => [...todoKeys.lists(), { filters }] as const,
};

export const useTodos = () => {
    const queryClient = useQueryClient();

    // Query for fetching todos
    const query = useQuery({
        queryKey: todoKeys.lists(),
        queryFn: async () => {
            const { data } = await todosApi.getAll();
            return data.items;
        },
    });

    // Mutation for creating todo
    const createMutation = useMutation({
        mutationFn: todosApi.create,
        onSuccess: () => {
            queryClient.invalidateQueries({ queryKey: todoKeys.lists() });
        },
        onError: () => { },
    });

    // Mutation for updating todo
    const updateMutation = useMutation({
        mutationFn: ({ id, ...data }: UpdateTodoDTO & { id: string }) =>
            todosApi.update(id, data),
        onSuccess: () => {
            queryClient.invalidateQueries({ queryKey: todoKeys.lists() });
        },
        onError: () => { },
    });

    // Mutation for deleting todo
    const deleteMutation = useMutation({
        mutationFn: todosApi.delete,
        onSuccess: () => {
            queryClient.invalidateQueries({ queryKey: todoKeys.lists() });
        },
        onError: () => { },
    });

    return {
        todos: query.data || [],
        isLoading: query.isLoading,
        isError: query.isError,
        createTodo: createMutation.mutateAsync,
        updateTodo: updateMutation.mutateAsync,
        deleteTodo: deleteMutation.mutateAsync,
    };
};