import { Input } from '@/components/ui/input';
import { Select, SelectContent, SelectItem, SelectTrigger, SelectValue } from '@/components/ui/select';
import { Switch } from '@/components/ui/switch';
import { Priority, Todo } from '@/types/todo';
import { useTodoFilters } from '../../hooks/useTodoFilters';

interface TodoFiltersProps {
    todos: Todo[];
}

export const TodoFilters = ({ todos }: TodoFiltersProps) => {
    const {
        filters,
        setSearchTerm,
        setPriorityFilter,
        setShowCompleted
    } = useTodoFilters(todos);

    return (
        <div className="space-y-4">
            <div className="flex gap-4">
                <Input
                    placeholder="Search todos..."
                    value={filters.searchTerm}
                    onChange={(e) => setSearchTerm(e.target.value)}
                    className="w-64"
                />
                <Select
                    value={filters.priorityFilter?.toString() ?? "All"}
                    onValueChange={(value) => setPriorityFilter(value !== "All" ? Number(value) : null)}
                >
                    <SelectTrigger className="w-40">
                        <SelectValue placeholder="Priority Filter" />
                    </SelectTrigger>
                    <SelectContent>
                        <SelectItem value="All">All Priorities</SelectItem>
                        <SelectItem value={Priority.Low.toString()}>Low</SelectItem>
                        <SelectItem value={Priority.Medium.toString()}>Medium</SelectItem>
                        <SelectItem value={Priority.High.toString()}>High</SelectItem>
                        <SelectItem value={Priority.Critical.toString()}>Critical</SelectItem>
                    </SelectContent>
                </Select>
                <div className="flex items-center gap-2">
                    <span>Show Completed</span>
                    <Switch
                        checked={filters.showCompleted}
                        onCheckedChange={setShowCompleted}
                    />
                </div>
            </div>
        </div>
    );
};