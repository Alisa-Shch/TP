﻿namespace Domain
{
    public class Role
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }

        private Role(Guid id, string name)
        {
            ArgumentException.ThrowIfNullOrEmpty(nameof(id));
            ArgumentException.ThrowIfNullOrEmpty(name, nameof(name));

            Id = id;
            Name = name;
        }

        public static Role Create(string name)
        {
            ArgumentException.ThrowIfNullOrEmpty(name, nameof(name));

            return new(Guid.NewGuid(), name);
        }
    }
}