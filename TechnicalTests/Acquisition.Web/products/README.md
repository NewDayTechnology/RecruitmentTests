# React + Vite Technical Interview Project

This project is designed for technical interviews. The interviewee will review the React and Node.js codebase, identify issues, suggest improvements, and walk us through their thought process. The focus will be on code quality, structure, and best practices.

## Objectives

- **Code Review**: Analyze the existing codebase for potential issues and areas of improvement.
- **Best Practices**: Suggest and implement improvements to align with industry standards.
- **Problem-Solving**: Demonstrate problem-solving skills by addressing identified issues.
- **Communication**: Clearly explain your thought process and decisions.

## Project Overview

This project uses [Vite](https://vitejs.dev/) for a fast and modern development experience with React. It includes:

- **React**: A JavaScript library for building user interfaces.
- **Vite**: A build tool that provides a fast development server and optimized production builds.
- **ESLint**: A tool for identifying and fixing problems in JavaScript code.

## Key Features

- Minimal setup to get React working in Vite with HMR (Hot Module Replacement) and some ESLint rules.
- Includes two official plugins:
  - [@vitejs/plugin-react](https://github.com/vitejs/vite-plugin-react/blob/main/packages/plugin-react): Uses [Babel](https://babeljs.io/) for Fast Refresh.
  - [@vitejs/plugin-react-swc](https://github.com/vitejs/vite-plugin-react/blob/main/packages/plugin-react-swc): Uses [SWC](https://swc.rs/) for Fast Refresh.

## Getting Started

1. **Install Dependencies**: Run `npm install` to install the required dependencies.
2. **Start Development Server**: Run `npm run dev` to start the development server.
3. **Build for Production**: Run `npm run build` to create a production build.
4. **Preview Production Build**: Run `npm run preview` to preview the production build locally.

## Expanding the ESLint Configuration

If you are developing a production application, we recommend using TypeScript with type-aware lint rules enabled. Check out the [TS template](https://github.com/vitejs/vite/tree/main/packages/create-vite/template-react-ts) for information on how to integrate TypeScript and [`typescript-eslint`](https://typescript-eslint.io) in your project.

## New Features

### Login Functionality
- Users can log in using a username and password.
- Login status is managed using a state variable (`isLoggedIn`).
- Alerts notify users of successful or failed login attempts.

### Wishlist Management
- Users can add or remove products from their wishlist.
- Wishlist data is persisted in `localStorage` for state retention across sessions.

### Product Fetching
- Products are fetched from a mock API (`https://fakestoreapi.com/products`).
- Error handling is implemented to manage API fetch failures.

### Basket Management
- Users can add products to their basket.
- Login is required to add items to the basket, with alerts guiding the user.

## Notes for Interviewees

- Focus on identifying and explaining issues related to code quality, structure, and best practices.
- Feel free to suggest and implement improvements.
- Be prepared to discuss your thought process and decisions during the interview.
