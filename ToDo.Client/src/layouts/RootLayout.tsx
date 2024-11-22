import { Outlet } from 'react-router-dom';

export const RootLayout = () => {
    return (
        <div className="min-h-screen">
            <main className="container mx-auto p-8">
                <Outlet />
            </main>
        </div>
    );
};