---
name: oop-patterns
description: skill for object oriented programming
---

# OOP Patterns

Use this skill when the user asks about class design, refactoring, inheritance vs composition, interfaces, dependencies, encapsulation, or applying common object-oriented patterns in this codebase.

## What to optimize for

- Keep classes small and focused on one responsibility.
- Prefer composition over inheritance unless the subtype relationship is truly stable.
- Use interfaces to define behavior boundaries, not as a default for every type.
- Preserve invariants inside the owning class or aggregate.
- Push business logic into services or domain objects instead of controllers.
- Keep DTOs, models, services, and repositories distinct.

## Default approach

1. Identify the behavior owner first.
2. Ask whether the logic belongs in a model, service, repository, or helper.
3. Extract abstractions only when there is a real variation point.
4. Prefer constructor injection for dependencies.
5. Keep mutation localized and explicit.

## Pattern guidance

- Use **Strategy** when the same operation has multiple interchangeable behaviors.
- Use **Factory** when object creation needs to hide branching or construction details.
- Use **Decorator** when you need to add behavior without changing the core type.
- Use **Template Method** only when a stable algorithm has a few overridable steps.
- Use **Repository** for persistence concerns, not for general business rules.

## C# / .NET preferences

- Prefer `record` or immutable DTOs for transport objects when practical.
- Keep controllers thin and delegate orchestration to services.
- Prefer `readonly` fields and readonly dependencies when possible.
- Avoid deep inheritance trees and over-abstracted base classes.
- Name abstractions by behavior, not implementation detail.

## Red flags

- A class that changes for multiple unrelated reasons.
- An interface with only one implementation and no clear variation point.
- Business rules duplicated across controllers or repositories.
- Base classes that exist only to share a small amount of code.
- Utility methods that hide domain rules instead of making them explicit.

## Response style

- Explain the ownership of the behavior first.
- Recommend the smallest change that improves structure.
- If a pattern is optional, say why it helps and when it would be unnecessary.
