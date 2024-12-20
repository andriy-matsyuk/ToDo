import { configureStore } from '@reduxjs/toolkit';
import { todoSlice } from './slices/todoSlice';

export const store = configureStore({
    reducer: {
        todos: todoSlice.reducer
    },
    middleware: (getDefaultMiddleware) =>
        getDefaultMiddleware({
            serializableCheck: false
        })
});

export type RootState = ReturnType<typeof store.getState>;
export type AppDispatch = typeof store.dispatch;