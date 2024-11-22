import { Priority } from '@/types/todo';
import { TodoList } from '@/features/todos/components/TodoList/TodoList';
import { AddTodo } from '@/features/todos/components/AddTodo/AddTodo';
import { useTodos } from '@/hooks/queries/useTodos';
import { Loader2 } from 'lucide-react';
import { TodoFilters } from '@/features/todos/components/TodoFilters/TodoFilters';
import { useTodoFilters } from '@/features/todos/hooks/useTodoFilters';

export const AllTodos = () => {
    const {
        todos,
        isLoading,
        isError,
        createTodo,
        updateTodo,
        deleteTodo
    } = useTodos();

    const { filteredTodos } = useTodoFilters(todos);

    const handleAddTodo = async (title: string, description: string, priority: Priority) => {
        await createTodo({
            title,
            description,
            priority
        });
    };

    const handleComplete = async (id: string) => {
        const todo = todos.find(t => t.id === id);
        if (!todo) return;

        await updateTodo({
            id,
            title: todo.title,
            description: todo.description,
            priority: todo.priority,
            isCompleted: !todo.isCompleted
        });
    };

    if (isLoading) {
        return (
            <div className="flex justify-center p-8">
                <Loader2 className="h-6 w-6 animate-spin" />
            </div>
        );
    }

    if (isError) {
        return (
            <div className="text-center text-red-500">
                Failed to load todos. Please try again later.
            </div>
        );
    }

    return (
        <div className="space-y-6">
            <h1 className="text-3xl font-bold">All Todos</h1>
            <AddTodo onAdd={handleAddTodo} />
            <TodoFilters todos={todos} />
            <TodoList
                title="Your Todos"
                todos={filteredTodos}
                onTodoComplete={handleComplete}
                onTodoDelete={deleteTodo}
            />
        </div>
    );
};