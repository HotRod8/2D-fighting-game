#include <iostream>
#include "Entity.h"

//***************
// Constructors *
//***************

Entity::Entity(const std::string& tag, const int& id) : TAG(tag), ID(id), active(true)
{

}

//************
// Functions *
//************

std::string Entity::getTag() const
{
	return TAG;
}

int Entity::getID() const
{
	return ID;
}

bool Entity::isActive() const
{
	return active;
}

void Entity::destroy()
{
	active = false;
}

//*******
// Test *
//*******

void Entity::test()
// Sample test to ensure Entity objects are created as intended.
{
	// Constructor test
	Entity e1("ally", 1);
	Entity e2("enemy", 3);

	// getTag(), getID() test
	std::cout << "e1 - TAG: " << e1.getTag() << ", ID: " << e1.getID() << '\n';
	std::cout << "e2 - TAG: " << e2.getTag() << ", ID: " << e2.getID() << "\n\n";

	// kill(), isActive() test
	e2.destroy();
	std::cout << "e1 alive? " << e1.isActive() << '\n';
	std::cout << "e2 alive? " << e2.isActive() << "\n\n";
}