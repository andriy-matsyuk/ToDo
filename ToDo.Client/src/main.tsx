import { StrictMode } from 'react'
import { createRoot } from 'react-dom/client'
import './index.css'
import App from './App.tsx'
import { ThemeProvider } from './components/common/theme-provider.tsx'
import { BrowserRouter } from 'react-router-dom'
import { QueryProvider } from './providers/QueryProvider.tsx'
import { Provider as ReduxProvider } from 'react-redux';
import { store } from './store/store.ts'

createRoot(document.getElementById('root')!).render(
  <StrictMode>
    <ReduxProvider store={store}>
      <ThemeProvider defaultTheme="dark" storageKey="ui-theme">
        <QueryProvider>
          <BrowserRouter>
            <App />
          </BrowserRouter>
        </QueryProvider>
      </ThemeProvider>
    </ReduxProvider>
  </StrictMode>,
)
